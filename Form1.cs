using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Relizar un CRUD(CREATE=INSERTAR, READ=LEER, UPDATE=ACTUALIZAR, DELETE=ELIMINAR)
namespace AppTutoria
{
    public partial class Form1 : Form
    {
        //configuramos la cadena de conexion
        SqlConnection conexion = new SqlConnection("server=LAPTOP-IUT020T4 ; database=BDTutoria ;" +
            " integrated security = true");
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
         
        }
        public void Listar()
        {
            conexion.Open();
            //realizamos la cadena de consulta
            string cadena1 = "select * from TTutor";
            //se utiliza para recuperar datos de la base de datos
            // creación del objeto de la clase SqlCommand pasando el string con el comando SQL 
            //y la referencia a la conexión
            SqlDataAdapter adaptador = new SqlDataAdapter(cadena1, conexion);
            //creamos una tabla virtual
            DataTable dt = new DataTable();
            //pasar la consulta a la tabla virtual
            adaptador.Fill(dt);
            //se muestra en el datagrid
            dgvTutoria.DataSource = dt;
            conexion.Close();
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //se carga los datos en el datagridview al momento de ejecutar el programa
            Listar();
            //se inicializa el cursor en la caja de texto Id_Tutor
            txtId.Focus();
        }
        public void Limpiar()
        {
            txtId.Text = "";
            txtNombres.Text = "";
            txtTitulo.Text = "";
            txtApellidos.Text = "";
            txtId.Enabled = true;
            txtId.Focus();
            btnInsertar.Enabled = true;
            Listar();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();//llamos al modulo limpiar para dejar las caja de texto limpias
        }

        private void dgvTutoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //este evento permiter recuperar los datos en cada caja texto, cada vez que se hace click en una fila
            // del datagrid
            txtId.Text = dgvTutoria.SelectedCells[0].Value.ToString();
            txtNombres. Text = dgvTutoria.SelectedCells[1].Value.ToString();
            txtApellidos .Text = dgvTutoria.SelectedCells[2].Value.ToString();
            txtTitulo.Text = dgvTutoria.SelectedCells[3].Value.ToString();
            txtId.Enabled = false;
            btnInsertar.Enabled = false;
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            //ingresando datos a la tabla TTutor
            //realizamos la cadena de consulta
            string cadena = "insert into TTutor(Id_tutor,Nombres, Apellidos,Titulo_Academico) values " +
                "('" + txtId.Text + "','" + txtNombres.Text + "','" + txtApellidos.Text + "','" + txtTitulo.Text + "')";
            // creación del objeto de la clase SqlCommand pasando el string con el comando SQL y la referencia a la conexión
            SqlCommand comando = new SqlCommand(cadena, conexion);
            //método ExecuteNonQuery se comunica con el SQL Server para que ejecute el comando configurado previamente
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");
            conexion.Close();
            Listar();
            Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar este registro? ", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();
                //realizamos la cadena de consulta
                string cadena = "delete from TTutor where Id_tutor= " + txtId.Text + "";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Los datos se eliminaron correctamente");
                conexion.Close();
                txtId.Enabled = false;
                Listar();
            }
            Limpiar();
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea actualizar este registro? ", "Actualizar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conexion.Open();
                //realizamos la cadena de consulta
                string cadena = "update  TTutor set Nombres='" + txtNombres.Text + "',Apellidos='" + txtApellidos.Text +
                    "',Titulo_Academico='" + txtTitulo.Text + "' where Id_tutor= " + txtId.Text;
                SqlCommand comando = new SqlCommand(cadena, conexion);
                int cant;
                cant = comando.ExecuteNonQuery();
                //Si es 1 es porque si encontro el registro
                if (cant == 1) MessageBox.Show("Los datos se actualizaron correctamente");
                else MessageBox.Show("Los datos no se actualizaron correctamente");

                conexion.Close();
                Listar();
            }
            Limpiar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            //realizamos la cadena de consulta
            string cadena = "select * from TTutor where Id_tutor= '" + txtId.Text + "'";
            SqlDataAdapter adaptador = new SqlDataAdapter(cadena, conexion);
            //creamos una tabla virtual
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dgvTutoria.DataSource = dt;
            conexion.Close();     
        }
    }
}
