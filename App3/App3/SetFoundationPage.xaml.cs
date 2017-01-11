using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App3
{
    public partial class SetFoundationPage : TabbedPage
    {
        public SetFoundationPage()
        {
            InitializeComponent();

            Children.Add(new CreateFoundation());
            Children.Add(new UpdateFoundation());
            Children.Add(new DeleteFoundation());
        }
    }
}
