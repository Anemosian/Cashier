using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashier
{
    public partial class SalesSummary : Form
    {
        private CashierDBEntities cdbe = new CashierDBEntities();
        public SalesSummary()
        {
            InitializeComponent();
            GenerateGraph();

            cboType.DataSource = cdbe.TblProductTypes.ToList();
            cboType.DisplayMember = "Description";
            cboType.ValueMember = "ProductType";
            cboType.SelectedIndex = -1;

            List<String> options = new List<String> {"Today","This Week","This Month","This Year", "All"};

            cboDate.DataSource = options;
            cboDate.SelectedIndex = -1;
        }

        private void GenerateGraph()
        {
            //string sqlString = "SELECT VALUE st FROM CashierDBEntities.TblProducts AS st WHERE st.ProductType == " + cboFilter.SelectedValue;
            //var objctx = (cdbe as IObjectContextAdapter).ObjectContext;

            //ObjectQuery<TblProduct> filteredProducts = objctx.CreateQuery<TblProduct>(sqlString);

            //chart1.DataSource = filteredProducts;

            //chart1.Series["Series1"].XValueMember = "ProductId";
            //chart1.Series["Series1"].YValueMembers = "TotalUnitSold";

            //chart1.Series["Series1"].Name = "Products";

            //chart1.DataBind();

            //chart1.Show();
            
        }
    }
}
