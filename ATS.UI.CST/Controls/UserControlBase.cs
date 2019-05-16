using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiseTech;

namespace ATS.UI.CST.Controls
{
	public partial class UserControlBase : UserControl
	{
		public event EventHandler OnClose;

		private Point targetLocation;
		private Size targetSize;
		private Point outLocation;
		private Size outSize;
		private Point inLocation;
		private Size inSize;
		private bool animating = false;
		private bool close = false;
		public UserControlBase()
		{
			InitializeComponent();
		}
		protected void TweenOut(Point location, Size size)
		{
			outLocation = location;
			outSize = size;
		}
		protected void TweenIn(Point location, Size size)
		{
			inLocation = location;
			inSize = size;
		}
		protected void TweenShow()
		{
			if (!animating)
			{
				Location = outLocation;
				Size = outSize;

				targetLocation = inLocation;
				targetSize = inSize;

				animating = true;
				CSTForm.OnAnimationUpdate += Core_OnAnimationUpdate; ;
				Refresh();
			}
		}
		protected void TweenHide(bool close)
		{
			this.close = close;
			if (!animating)
			{
				targetLocation = outLocation;
				targetSize = outSize;

				animating = true;
				CSTForm.OnAnimationUpdate += Core_OnAnimationUpdate; ;
				Refresh();
			}
		}

		private void UserControlBase_OnAnimationEnd(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		protected void TweenEnd()
		{
			if (animating)
			{
				CSTForm.OnAnimationUpdate -= Core_OnAnimationUpdate;
				animating = false;
			}
			if (close)
			{
                if (OnClose != null)
                {
                    OnClose.Invoke(this, new EventArgs());
                }
				
			}
		}

		private void Core_OnAnimationUpdate(object sender, EventArgs e)
		{
			ThreadSafeHelper.UIThread(this,() =>
			{
				SuspendLayout();
				Point delta = targetLocation - new Size(Location);
				Size deltaSize = targetSize - Size;

				//距離差除2後 
				//(若在+2~-2之間則直接視為到達 用右移方式 +1和-1右移1會是0 所以不需要判斷是否在+2~-2間)
				delta.X >>= 1;
				delta.Y >>= 1;
				deltaSize.Width >>= 1;
				deltaSize.Height >>= 1;

				Location += new Size(delta.X, delta.Y);
				Size += deltaSize;

				if (delta.X == 0 && delta.Y == 0 && deltaSize.Width == 0 && deltaSize.Height == 0)
				{
					Location = targetLocation;
					Size = targetSize;
					TweenEnd();
				}
				ResumeLayout();
			});
		}

	}
}
