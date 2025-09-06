using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_descricao.Text) || 
                string.IsNullOrWhiteSpace(txt_quantidade.Text) || 
                string.IsNullOrWhiteSpace(txt_preco.Text))
            {
                await DisplayAlert("Erro", "Preencha todos os campos para salvar.", "OK");
                return; 

            }
                
            if (double.TryParse(txt_quantidade.Text, out double quantidade) &&
                double.TryParse(txt_preco.Text, out double preco))
            {
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = quantidade,
                    Preco = preco
                };
                
                await App.Db.Insert(p);
                await DisplayAlert("Sucesso!", "Produto salvo com sucesso.", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Erro de conversão", "A quantidade e o preço devem ser números válidos.", "OK");
            }

         }catch (Exception ex)

        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}