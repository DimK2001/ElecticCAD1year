using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsElectronicCAD
{
    public partial class CreateDialog : Form
    {
        Form1 form;
        public CreateDialog(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            form.CreateNewScheme((int)Xsize.Value, (int)Ysize.Value);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
