
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace Autenticacao
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
          
        }

        private void FecharFormulario(object? enviado, EventArgs args)
        {

            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyDcuLElUvnMMO0ITWk85bTNIpX31KN4GH8",

                AuthDomain = "project-1485364354951344690.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {

                    new EmailProvider()
                },
                UserRepository = new FileUserRepository("NossosDados")



            };
            var cliente = new FirebaseAuthClient(config);
            cliente.SignOut();
            Login login = new Login();
            this.Hide();
            login.Closed += fecharFormulario;
            login.Show();
            //this.Close();
        }

        private void fecharFormulario(object? enviado, EventArgs args)
        {

            this.Close();

        }

    }
    
    }

