
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace inizioMaui
{
    public partial class MainPage : ContentPage
    {

        private int _indovinaNumero;
        private int _counter;

        public MainPage()
        {
            InitializeComponent();
            InizializzaPartita();
        }

        private async void btnNumber_Click(object sender, EventArgs e)
        {
            try
            {
                _counter++;
                int numeroIndovinato = int.Parse(entryNumber.Text);
                if (numeroIndovinato == _indovinaNumero)
                {
                    lblHint.Text = "Hai Vinto in " + _counter + " tentativi!";
                    lblTentativi.Text = "";
                    btnNuovaPartita.IsVisible = true;
                    bntCounter.IsVisible = false; 
                    
                    return;
                }
                else if (numeroIndovinato > _indovinaNumero)
                {
                    if (numeroIndovinato > 100) { await DisplayAlert("Errore", "Il numero deve essere minore di 100", "OK, ne reinserisco un altro"); _counter--; }
                    lblHint.Text = "Il numero da indovinare è più piccolo";
                }
                else
                {
                    lblHint.Text = "Il numero da indovinare è più grande";
                }
                lblTentativi.Text = "Hai fatto " + _counter + " tentativi"; 
            }
            catch
            {
                await DisplayAlert("Errore", "Si inserisca un numero", "OK");
            }

        }

        private async Task DisplayAlert(string v)
        {
            throw new NotImplementedException();
        }

        private void btnNuovaPartita_Clicked(object sender, EventArgs e)
        {
            InizializzaPartita(); 

        }

        private void InizializzaPartita()
        {
            Random numero = new Random();
            _indovinaNumero = (int)numero.Next(1, 100);
            _counter = 0;
            bntCounter.IsVisible = true;
            btnNuovaPartita.IsVisible = false;
            entryNumber.Text = "";
            entryNumber.Placeholder = "";
            lblHint.Text = ""; 

        }
    }

}
