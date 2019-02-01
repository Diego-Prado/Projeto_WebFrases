using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrases.dal;
using WebFrases.model;

namespace WebFrases
{
    public partial class categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
        public void AtualizarGrid()
        {
            DalCategoria dal = new DalCategoria();
            GridView1.DataSource = dal.Localizar();
            GridView1.DataBind();
        }

        private void LimparCampos()
        {
            txtID.Text = "";
            txtNome.Text = "";
            btnInserir.Text = "Inserir";
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            String msg = "";
            DalCategoria dal = new DalCategoria();
            ModeloCategoria obj = new ModeloCategoria();
            obj.categoria = txtNome.Text;

            try
            {
                if (btnInserir.Text == "Inserir")
                {
                    //inserir
                    dal.Inserir(obj);
                    msg = "<script> alert('O código gerado foi o : " + obj.id.ToString() + "'); </script>";

                }
                else
                {
                    //alterar
                    obj.id = Convert.ToInt32(txtID.Text);
                    dal.Alterar(obj);
                    msg = "<script> alert('O registro foi alterado corretamente!'); </script>";

                }
                Response.Write(msg);
                this.LimparCampos();
            }
            catch (Exception erro)
            {
                //colocar um javascript
                Response.Write("<script> alert('" + erro.Message + "'); </script>");
            }
            AtualizarGrid();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int cod = Convert.ToInt32(GridView1.Rows[index].Cells[1].Text);
            DalCategoria dal = new DalCategoria();
            dal.Excluir(cod);
            AtualizarGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

            int index = GridView1.SelectedIndex;
            int cod = Convert.ToInt32(GridView1.Rows[index].Cells[1].Text);
            DalCategoria dal = new DalCategoria();
            ModeloCategoria  c = dal.GetRegistro(cod);
                if (c.id != 0)
                {
                    txtID.Text = c.id.ToString();
                    txtNome.Text = c.categoria;
                    btnInserir.Text = "Alterar";
                }
            }
            catch
            {

            }
        }
    }
}