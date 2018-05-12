using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EJEMPLO_PRACTICAS
{
    public partial class Form1 : Form
    {
        
        enum accion { agregar, modificar, eliminar, nada }

        accion proceso = accion.nada;


        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            llenar_Grid();

        }

        int poc;
     private void llenar_Grid()

     {
         var listado = from x in new DBEJEMPLO().elliot__1
                       select x;
         DataGridView1.DataSource = listado.ToList();
    }

        private void txRfc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpAgregar_Click(object sender, EventArgs e)
        {
            activar();
            proceso = accion.agregar;
            DataGridView1.Enabled = false;
        }

        private void activar()
        { 

         this.OpAgregar.Enabled = !this.OpAgregar.Enabled;
            this.OpModificar.Enabled = !this.OpModificar.Enabled;
            this.OpEliminar.Enabled = !this.OpEliminar.Enabled;
            this.OpCancelar.Enabled = !this.OpCancelar.Enabled;
            this.OpGuardar.Enabled = !this.OpGuardar.Enabled;
        }

        private void OpModificar_Click(object sender, EventArgs e)
        {
            activar();
            proceso = accion.modificar;
        }

        private void OpEliminar_Click(object sender, EventArgs e)
        {
            activar();
            proceso = accion.eliminar;

            var BORRAR = BaseDAL.Eliminar<elliot__1>(x => x.idPersona == poc);
            llenar_Grid();
            

        }

        private void OpCancelar_Click(object sender, EventArgs e)
        {
            activar();
        }

        private void OpGuardar_Click(object sender, EventArgs e)
        {
            if (proceso == accion.agregar)
            {

                if (CapturaCorrecta() == false)
                {
                    MessageBox.Show("Captura Incorrecta");
                    return;

                }



                





                var registro = new elliot__1();

                registro.idPersona = Int32.Parse(this.txIdPersona.Text);
                registro.Nombre = this.txNombre.Text.ToUpper();
                registro.Domicilio = this.txDomicilio.Text.ToUpper();
                registro.Rfc = this.txRfc.Text.ToUpper();
                registro.FechaNac = this.FechaNac.Value;
                registro.Activo = this.CheckActivo.Checked;


                var BASE = new DBEJEMPLO();

                BASE.elliot__1.Add(registro);

                BASE.SaveChanges();

                DataGridView1.Enabled = true;

                llenar_Grid();
            }


            if (proceso == accion.modificar)
            {
                

                DataGridView1[0, poc].Value = txIdPersona.Text.ToUpper();
                DataGridView1[1, poc].Value = txNombre.Text.ToUpper();
                DataGridView1[2, poc].Value = txDomicilio.Text.ToUpper();
                DataGridView1[4, poc].Value = txRfc.Text.ToUpper();
                DataGridView1[3, poc].Value = FechaNac.Value;
                DataGridView1[5, poc].Value = CheckActivo.Checked;
                {
                    MessageBox.Show("Se a modificado correctamente");
                    return;
                    
                    
                }

                

            }
            


            activar();
        }

        private bool CapturaCorrecta()
        {
            bool valor = true;
            if (this.txNombre.Text == string.Empty) valor = false;
            if (this.txRfc.Text == string.Empty) valor = false;
            if (Int32.Parse(this.txIdPersona.Text) == 0) valor = false;
            if (this.txDomicilio.Text == string.Empty) valor = false;
            if (FechaNac.Value > DateTime.Today) valor = false;

            return valor;
        

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = DataGridView1.CurrentRow.Index;
            txIdPersona.Text = DataGridView1[0,poc].Value.ToString();
            txNombre.Text = DataGridView1[1, poc].Value.ToString();
            txDomicilio.Text = DataGridView1[2, poc].Value.ToString();
            txRfc.Text = DataGridView1[4, poc].Value.ToString();
            
            

        }


        private bool idRepetido()
        {
            bool valor = false;
            
            var idpers = Int32.Parse(this.txIdPersona.Text);

            var reg = from regis in new DBEJEMPLO().elliot__1
                      where regis.idPersona == idpers
                      select regis;




            return valor;
        
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var BORRAR = BaseDAL.Eliminar<elliot__1>(x => x.idPersona == poc);



            llenar_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {




        }

       
           
    
    }
}

