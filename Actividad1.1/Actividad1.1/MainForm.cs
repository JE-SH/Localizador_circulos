/*
 * Created by SharpDevelop.
 * User: JESH
 * Date: 31/01/2020
 * Time: 05:51 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Actividad1._
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//


		}
		void AgregarImagenClick(object sender, EventArgs e)
		{
			OpenFD.ShowDialog();
			Image img = Image.FromFile(OpenFD.FileName);
			pictureBox1.Image = img;
		}
		void AnalizarImagenClick(object sender, EventArgs e)
		{
			Bitmap btm = new Bitmap(OpenFD.FileName);
			List <Point>LP = new List<Point>();
			List <int> rad = new List<int>();
			int cont=0;
			textBox1.Text = "";
			
			for(int y=0; y<btm.Height;y++){
				for(int x=0; x<btm.Width; x++)
				{
					Color c= btm.GetPixel(x,y);
					if(c.R!=255)
						if(c.G !=255)
							if(c.B !=255)
								if(c.R != 100)
									if(c.G != 100)
										if(c.B != 200)
							{
								Point p = findCenter(x,y,btm);							
								
								Point r = findRadio(p.X,p.Y,btm);
								if (r.X==0){
									rad.Add(r.Y);
									LP.Add(p);
									
									isCircle(p.X,	y,btm,true);
									drawCenter(p.X,p.Y,btm);
									
									cont++;
								}
								else
									isCircle(p.X,y,btm,false);
							}
					
				}
			}
			for(int i = 0;i<cont;i++)
			{
				textBox1.Text += "EJE X: "+LP[i].X.ToString().PadRight(6)+"   EJE Y: "+LP[i].Y.ToString().PadRight(6)+
					"   RADIO: "+rad[i].ToString().PadRight(6)+"\r\n";
			}
		}
		Point findCenter(int x,int y,Bitmap btm)
		{
			int xx,yy;
				for(xx = x;xx<btm.Width;xx++)
				{
					Color c = btm.GetPixel(xx,y);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				xx--;
				int xc = (xx - x)/2;
				int xt = x+xc;
				for(yy =y;yy<btm.Height;yy++)
				{
					Color c = btm.GetPixel(xt,yy);
					if(c.R ==255)
						if(c.G ==255)
							if(c.B ==255)
								break;
				}
				yy--;				
			int yc = (yy - y)/2;
			
			return new Point(xt,y+yc);
			}
		Point findRadio(int x,int y,Bitmap btm)
		{
			int x1,y1;
		//+x
			for(x1=x;x1<btm.Width;x1++)
			{
				Color c = btm.GetPixel(x1,y);
				if(c.R ==255)
					if(c.G ==255)
						if(c.B ==255)
							break;
			}
			x1--;
	//y+
			for(y1=y;y1<btm.Height;y1++)
			{
				Color c = btm.GetPixel(x,y1);
				if(c.R ==255)
					if(c.G ==255)
						if(c.B ==255)
							break;
			}
			y1--;
				int yt = y1-y;
				int xt = x1-x;
				
				if(xt-yt<6)
					if(xt-yt>-6)
						return new Point(0,xt); // circulo
						 			//no circulo
					return new Point(1,xt);				
		}
		void isCircle(int x, int y,Bitmap btm, bool op)
		{
			if(op == true)
			{
				Color Myc = new Color();
				Myc = Color.FromArgb(100,10,10,200);
				
				paintCircle(x,y,btm,Myc);
			}
			if(op == false)
			{
				paintCircle(x,y,btm,Color.White);
			}
			
		}
		void paintCircle(int x, int y,Bitmap btm,Color col)
		{
//y+
					for(int y1=y;y1<btm.Height;y1++)		
					{
						if(y1<0)
							break;
						Color c1 = btm.GetPixel(x,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
		//x+				
						for(int x1=x;x1<btm.Width;x1++)
						{
							c1 = btm.GetPixel(x1,y1);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							btm.SetPixel(x1,y1,col);
						}
		//x-
						for(int x2=x-1;x2<btm.Width;x2--)
						{
							if(x2<0)
								break;
							c1 = btm.GetPixel(x2,y1);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							btm.SetPixel(x2,y1,col);
						
					}
				}	
				
				pictureBox1.Image = btm;
			}

		void drawCenter(int x, int y,Bitmap btm)
		{
			for(int i=x-5; i<x+5;i++){
				for(int j=y-5; j<y+5; j++){
						btm.SetPixel(i,j,Color.OrangeRed);
				}
			}
				pictureBox1.Image = btm;
		}			
		}
		
	}



