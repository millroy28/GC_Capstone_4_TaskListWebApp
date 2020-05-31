using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_CAPSTONE4_TASKLIST.Models
{
    public class ViewOptions
    {
        public string viewPref { get; set; }
        public int viewId { get; set; }

        public ViewOptions()
        {

        }

        public ViewOptions(string _viewPref)
        {
            viewPref = _viewPref;
            viewId = 0;
        }

        public ViewOptions(string _viewPref, int _viewId)
        {
            viewPref = _viewPref;
            viewId = _viewId;
        }
    }
}
