namespace CalculadoraPeso
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCalcularClicked(object sender, EventArgs e)
        {
            string pesoText = PesoEntry.Text?.Replace(',', '.') ?? "";
            string alturaText = AlturaEntry.Text?.Replace(',', '.') ?? "";

            bool esPesoValido = double.TryParse(pesoText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double peso);
            bool esAlturaValida = double.TryParse(alturaText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double altura);

            if (esPesoValido && esAlturaValida && peso > 0 && altura > 0)
            {
                double imc = peso / (altura * altura);
                ResultadoLabel.Text = $"Tu IMC es: {imc:F2}";
            }
            else
            {
                ResultadoLabel.Text = "";
                await DisplayAlert("Datos no válidos", "Por favor, introduce valores numéricos mayores que cero para el peso y la altura.", "OK");
            }
        }
    }
}