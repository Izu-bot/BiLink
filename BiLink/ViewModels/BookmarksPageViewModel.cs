using BiLink.Models;
using BiLink.Models.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiLink.ViewModels
{
    public class BookmarksPageViewModel : BindableObject
    {
        private readonly Models.Service.ICategoriaService _categoriaService;
        private int _currentPage = 1;
        private const int PageSize = 20;

        private bool _isLoadingMore;
        public bool IsLoadingMore
        {
            get => _isLoadingMore;
            set
            {
                _isLoadingMore = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
           {
                _name = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Categorias> Categorias { get; } = new ObservableCollection<Categorias>();

        public ICommand LoadCategoriaCommand { get; }
        public ICommand AddBookmark { get; }

		public BookmarksPageViewModel(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService ?? throw new ArgumentException(nameof(categoriaService));

            LoadCategoriaCommand = new Command(async () => await ExecuteLoadCategoriaCommand());
            AddBookmark = new Command(async () => await ExecuteAddBookmarkCommand());
		}

        private async Task ExecuteAddBookmarkCommand()
        {
            if (string.IsNullOrWhiteSpace(Name))
                return;

            var nameExists = await _categoriaService.GetCategoriaByName(Name);

            if (nameExists != null)
            {
                Name = string.Empty;
                return;
            }

			var newCategoria = new Categorias
            {
                Nome = Name
            };

            await _categoriaService.AddCategoria(newCategoria);

            await ExecuteLoadCategoriaCommand();

            Name = string.Empty;
		}

        private async Task ExecuteLoadCategoriaCommand()
        {
            if (IsLoadingMore)
                return;

            try
            {
                IsLoadingMore = true;
                _currentPage = 1;
                Categorias.Clear();

                var categorias = await _categoriaService.GetAllCategorias(_currentPage, PageSize);

                foreach (var categoria in categorias)
                {
                    Categorias.Add(categoria);
				}
			}
            finally
            {
                IsLoadingMore = false;
            }
        }
    }
}
