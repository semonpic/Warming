using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiseTech
{
	public static class ThreadSafeHelper
	{
		public static void UIThread(Control control, Action code)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(code);
				return;
			}
			code.Invoke();
		}

		public static void UIThreadInvoke(Control control, Action code)
		{
			if (control.InvokeRequired)
			{
				control.Invoke(code);
				return;
			}
			code.Invoke();
		}

	}
}
