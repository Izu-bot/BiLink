using BiLink.Models;
using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiLink.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private readonly Models.Service.ILinkService _linkService;
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

        private string _url;
        public string Url
        {
            get => _url;
            set
            {
                _url = value;
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

        private string _categoria;
        public string Categoria
        {
            get => _categoria;
            set
            {
                _categoria = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Link> Links { get; } = new ObservableCollection<Link>();

        public ICommand LoadLinksCommand { get; }
        public ICommand AddLinkCommand { get; }

        public ICommand DeleteLinkCommand { get; }
        public ICommand CopyLink { get; }

        public MainPageViewModel(Models.Service.ILinkService linkService)
        {
            _linkService = linkService ?? throw new ArgumentNullException(nameof(linkService));

            LoadLinksCommand = new Command(async () => await LoadLinksAsync());
            AddLinkCommand = new Command(async () => await AddLinkAsync());
            DeleteLinkCommand = new Command<Link>(async (link) => await DeleteLinkAsync(link));
            CopyLink = new Command<Link>(async (link) => await ExecuteCopy(link));
        }

        private async Task LoadLinksAsync()
        {
            if (IsLoadingMore) return; // Evita chamadas concorrentes

            try
            {
                IsLoadingMore = true;
                _currentPage = 0;
                Links.Clear();

                var links = await _linkService.GetAllLinks(++_currentPage, PageSize);
                foreach (var link in links)
                {
                    Links.Add(link);
                }
            }
            finally
            {
                IsLoadingMore = false;
            }
        }


        private async Task AddLinkAsync()
        {
            if (string.IsNullOrWhiteSpace(Url) || string.IsNullOrWhiteSpace(Name))
                return;

            var newLink = new Link
            {
                Nome = Name,
                URL = Url,
                CategoriaId = int.TryParse(Categoria, out int catId) ? catId : 0
            };

            await _linkService.AddLink(newLink);

            await LoadLinksAsync();

            // Limpa os campos
            Url = string.Empty;
            Name = string.Empty;
            Categoria = string.Empty;
        }

        private async Task DeleteLinkAsync(Link link)
        {
            if (link == null) return;

            bool resposta = await Application.Current!.Windows[0].Page!.DisplayAlert("Confirmação", $"Deseja excluir o link '{link.Nome}'?", "Sim", "Não");

            if (resposta)
            {
                await _linkService.DeleteLink(link);
                Links.Remove(link);
            }
        }

        private async Task ExecuteCopy(Link link)
        {
            if (link == null) return;

            await Clipboard.Default.SetTextAsync(link.URL);
        
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var toast = Toast.Make("Link copiado para a área de transferência!", CommunityToolkit.Maui.Core.ToastDuration.Short, 14);
                await toast.Show();
            });
        }
    }
}
