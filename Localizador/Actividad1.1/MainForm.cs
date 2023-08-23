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
		static int VALOR_DE_RANGO = 6;

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
			Bitmap bitmap = new Bitmap(OpenFD.FileName);
			List <Point>ListaPuntos = new List<Point>();
			List <int> ListaRadios = new List<int>();
			int cont = 0;
			textBox1.Text = "";
			
			for(int y=0; y<bitmap.Height;y++){
				for(int x=0; x<bitmap.Width; x++)
				{
					Color color = bitmap.GetPixel(x,y);
					//El color es distinto de blanco?
					if(color.R!=255)
						if(color.G !=255)
							if(color.B !=255)
								//El color es distinto de azul? Para los círculos validados
								if(color.R != 100)
									if(color.G != 100)
										if(color.B != 200)
							{
								
								Point circulo = findCenter(x,y,bitmap);

								// Retorna como primer parámetro un boleano y el segundo como la distancia del radio
								Point r = radioCompare(circulo.X,circulo.Y,bitmap); 
								int v = circulo.X- r.Y;
							
								if (r.X==0){
									isCircle(circulo.X,y,bitmap,true,1);
									drawCenter(circulo.X,circulo.Y,bitmap);
									ListaRadios.Add(v);
									ListaPuntos.Add(circulo);
									cont++;
								}
								else if(r.X==1)
									isCircle(r.Y,y,bitmap,false,2);
								else
									isCircle(x,r.Y,bitmap,false,1);
							}
					
				}
			}
			for(int i = 0;i<cont;i++)
			{
				textBox1.Text += "EJE X: "+ListaPuntos[i].X.ToString().PadRight(6)+"   EJE Y: "+ListaPuntos[i].Y.ToString().PadRight(6)+
					"   ListaRadiosIO: "+ListaRadios[i].ToString().PadRight(6)+"\r\n";

			}
		}
		Point findCenter(int x,int y,Bitmap bitmap)
		{
			int xx,yy;
			//Distancia de pixeles diferentes a blanco
			for(xx = x;xx<bitmap.Width;xx++)
			{
				Color color = bitmap.GetPixel(xx,y);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
			}
			xx--;

			int x_radio = (xx - x)/2;
			int x_centro = x+x_radio;
			for(yy =y;yy<bitmap.Height;yy++)
			{
				Color color = bitmap.GetPixel(x_centro,yy);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
			}
			yy--;
				
			int y_radio = (yy - y)/2;
			
			return new Point(x_centro,y+y_radio);
			}
		Point radioCompare(int x,int y,Bitmap bitmap)
		{
			int x1,x2,y1,y2;
			//-x Recorrido en x a la izquierda
			for(x1=x;x1<bitmap.Width;x1--)
			{
				if(x1<0)
					break;
				Color color = bitmap.GetPixel(x1,y);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
			}
			x1++;

			//+x Recorrido en x a la derecha
			for (x2=x;x2<bitmap.Width;x2++)
			{
				Color color = bitmap.GetPixel(x2,y);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
			}
				x2--;
		//y- Recorrido en y hacia arriba
			for(y1=y;y1<bitmap.Height;y1--)
			{
				if(y1<0)
					break;
				Color color = bitmap.GetPixel(x,y1);
				//color = bitmap.GetPixel(x,y1);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
					
			}
			y1++;
		//y+ Recorrido en y hacia abajo
			for(y2=y;y2<bitmap.Height;y2++)
			{
				Color color = bitmap.GetPixel(x,y2);
				if(color.R ==255)
					if(color.G ==255)
						if(color.B ==255)
							break;
			}
			y2--;

			int yt = y-y1;
			int ytt = y2-y;
			int xt = x-x1;
			int xtt = x2-x;
			int y_radio,x_radio;
			y_radio = (yt + ytt)/2;
			x_radio = (xt + xtt)/2;

			if(yt-ytt < VALOR_DE_RANGO && yt-ytt>-VALOR_DE_RANGO)
			{
				if(xt-xtt< VALOR_DE_RANGO && xt-xtt>-VALOR_DE_RANGO)	
					if(x_radio-y_radio< VALOR_DE_RANGO  && x_radio-y_radio>-VALOR_DE_RANGO)
				{
				/*y_radio = (y-y1);
				x_radio = (x-x1);
				if(x_radio-y_radio<11)
					return 0;
				if(y_radio-x_radio<11)
					return 0;*/
				return new Point(0,x1); // circulo
				}
			}
				

				if(y_radio - x_radio > 10) 			//no circulo
					return new Point(1,x1);
				//if(x_radio - y_radio > 10)
					return new Point(2,y1);;
					
				
			
		}
		void isCircle(int x, int y,Bitmap bitmap, bool op,int n)
		{
			if(op == true)
			{
				Color Myc = new Color();
				Myc = Color.FromArgb(100,10,10,200);
				
				paintCircle(x,y,bitmap,Myc,n);
			}
			if(op == false)
			{
				paintCircle(x,y,bitmap,Color.White,n);
			}
			
		}
		void paintCircle(int x, int y,Bitmap bitmap,Color col, int n)
		{
					Color c1 = bitmap.GetPixel(x,y);
					if(n==2)
					for(int x1=x;x1<bitmap.Width;x1++)		
					{
						if(x1<0)
							break;
						c1 = bitmap.GetPixel(x1,y);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
		//x+				
						for(int y1=y;y1<bitmap.Height;y1++)
						{
							c1 = bitmap.GetPixel(x1,y1);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							bitmap.SetPixel(x1,y1,col);
						}
		//x-
						for(int y2=y-1;y2<bitmap.Width;y2--)
						{
							if(y2<0)
								break;
							c1 = bitmap.GetPixel(x1,y2);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							bitmap.SetPixel(x1,y2,col);
						
					}
				}
				else
				{
//y+
					for(int y1=y;y1<bitmap.Height;y1++)		
					{
						if(y1<0)
							break;
						c1 = bitmap.GetPixel(x,y1);
						if(c1.R ==255)
							if(c1.G ==255)
								if(c1.B ==255)
									break;
		//x+				
						for(int x1=x;x1<bitmap.Width;x1++)
						{
							c1 = bitmap.GetPixel(x1,y1);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							bitmap.SetPixel(x1,y1,col);
						}
		//x-
						for(int x2=x-1;x2<bitmap.Width;x2--)
						{
							if(x2<0)
								break;
							c1 = bitmap.GetPixel(x2,y1);
							if(c1.R ==255)
								if(c1.G ==255)
									if(c1.B ==255)
										break;
							bitmap.SetPixel(x2,y1,col);
						
					}
				}
				}		
				
				pictureBox1.Image = bitmap;
			}

		void drawCenter(int x, int y,Bitmap bitmap)
		{
			for(int i=x-5; i<x+5;i++){
				for(int j=y-5; j<y+5; j++){
						bitmap.SetPixel(i,j,Color.OrangeRed);
				}
			}
				pictureBox1.Image = bitmap;
		}
		
		
		
		}
		
	}

