namespace Autenticacao
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            this.Hide();
            cadastro.Closed += fecharFormulario;
            cadastro.Show();
            //this.Close();
        }

        private void fecharFormulario(object? enviado, EventArgs args)
        {

            this.Close();

        }
      
    }
}