namespace BiLink
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new MainWindow()
            {
                Width = 900,
                Height = 600,
                MaximumHeight = 600,
                MinimumHeight = 600,
                MaximumWidth = 900,
                MinimumWidth = 900
            };
        }
    }
}