
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace Autenticacao
{
    public partial class Cadastro : Form
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;


        public Cadastro()
        {
            InitializeComponent();
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("project-1485364354951344690-firebase-adminsdk-vr9y9-f8e69d2f14.json")




            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox2.Text != textBox3.Text)
            {

                MessageBox.Show("As Senhas não batem, favor revisar");
                return;

            }

            if(textBox2.Text.Length <= 8)
            {

                MessageBox.Show("Digite uma senha com no minimo 8");
                return;

            }

            try
            {


                var usuario = FirebaseAuth.DefaultInstance.CreateUserAsync(new UserRecordArgs()
                {

                    Email = textBox1.Text,
                    Password = textBox2.Text,

                }).Result;
                MessageBox.Show(usuario.Uid);
                MessageBox.Show(usuario.EmailVerified.ToString());

                Principal principal = new Principal();
                Hide();
                principal.FormClosed += fecharFormulario;
                principal.Show();
                    
            }

            catch(Exception ex)
            {
                if(ex.Message.Contains(
                    "The user with the provided email already exists (EMAIL_EXISTS)"
                    
         
                    ))
                {
                    MessageBox.Show("Já existe o e-mail cadastrado");

                }

                else
                {
                    MessageBox.Show("Erro: " + ex.Message);

                }
                //é extremamente importante que o sistema tenha logs
                MessageBox.Show(ex.Message);
               // Clipboard.SetText(ex.Message);

            }
        }
    }
}
