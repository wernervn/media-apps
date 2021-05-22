using System.Collections.Generic;
using System.Windows.Forms;

namespace SeriesNavigator
{
    public static class ControlExtensions
    {
        public static IEnumerable<TType> All<TType>(this Control.ControlCollection controls) where TType : class
        {
            foreach (Control control in controls)
            {
                //if (control.HasChildren)
                //{
                //    foreach (TType child in control.Controls.All<TType>())
                //    {
                //        if (child.GetType() == typeof(TType))
                //            yield return child as TType;
                //    }
                //}
                //else
                //{
                //    if (control.GetType() == typeof(TType))
                //        yield return control as TType;
                //}
                if (control.GetType() == typeof(TType))
                    yield return control as TType;
            }
        }
    }
}
