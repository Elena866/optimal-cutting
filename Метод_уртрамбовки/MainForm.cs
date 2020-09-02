/*
 * Created by SharpDevelop.
 * User: Елена
 * Date: 19.02.2019
 * Time: 19:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Метод_уртрамбовки
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			
			
			InitializeComponent();
			Draw();
			//продемонстрировать именно на 9*19
			
		
		}
		public void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
			Graphics graph = Graphics.FromImage(bmp);
			Pen pen = new Pen(Color.Black);
			//graph.DrawLine(pen,10,50,150,200);
			graph.DrawRectangle(pen,0,0,400,200);
			//graph.DrawLine(pen,a,b,a,p);
			pictureBox1.Image=bmp;
		}
		
		
		int ostatok500=0;
		int ostatok400=0;
	
		void Button1Click(object sender, EventArgs e)
		{	
			if ( textBox3.TextLength !=0 || textBox4.TextLength !=0)
			{
					
				 if(textBox3.TextLength !=0 & textBox4.TextLength !=0) // введено в поля 500 и 400
			{                                              
				Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
				Graphics graph = Graphics.FromImage(bmp);
				Pen pen = new Pen(Color.Black);
				graph.DrawRectangle(pen,0,0,400,200);
				pictureBox1.Image=bmp;
				
				int n400 = Convert.ToInt32(Convert.ToUInt32(textBox4.Text));//кол-во деталей по 400мм
				int n500 = Convert.ToInt32(Convert.ToUInt32(textBox3.Text));//кол-во деталей по 500мм
				
				
				 	int billetsFor500 = n500/8;//целые заготовки по 500
					int billetsFor400 = n400/10;//целые заготовки по 400
					
					double ostatokbilletsFor500 = n500%8;//остаток от заготовки по 500
					double ostatokbilletsFor400 = n400%10;//остаток от заготовки по 400
					
					int billetsFor500end400=billetsFor400+billetsFor500;// всего целых заготовок
					
					if(ostatokbilletsFor500==0 & ostatokbilletsFor400==0 )// 500 четное 8 и 400 четное 10
					{
						label6.Text="Поздравляем! Ваши отходы составляют 0 мм.";
						label7.Text="Вам нужно "+billetsFor500end400 + " станд.форм";
						label1.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм.";
					    label2.Text="500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
					    
					}
					
					else if(ostatokbilletsFor500!=0 | ostatokbilletsFor400!=0 )
					{
						int ostatokFor500=n500-billetsFor500*8;// остаток деталей в количестве(1,2...) по 500 // 1-500 2-1000 3-1500 4-2000 5-2500 6-3000 7-3500
					    int ostatokFor400=n400-billetsFor400*10;// остаток деталей по 400  // 1-400 2-800  3-1200 4-1600 5-2000 6-2400 7-2800 8-3200 9-3600 
					
						//label6.Text="Остаток от 500: " +ostatokFor500.ToString();
						//label7.Text="Остаток от 400: " +ostatokFor400.ToString();
						
					    if(ostatokFor500==4 & ostatokFor400==5)//готово
						{
							billetsFor500end400= billetsFor500end400+1;
							label7.Text="Вам нужно " +billetsFor500end400.ToString()+" шт. станд.форм.";
							label6.Text="Поздравляем! Ваши отходы составляют 0 мм.";
							label1.Text="400*5 и 500*4";
							label2.Text="500*8= "+billetsFor500.ToString()+" шт.станд.форм и 400*10= "+billetsFor400.ToString()+" шт.станд.форм.";
							int g1=4;//500
							int g2=4;//400
							int a=40,b=0,c=40,d=200;
							do
							{
								graph.DrawLine(pen,a,b,c,d);
								g2--;
								a=a+40;
								c=c+40;
							}while(g2>0);
							do
							{
								graph.DrawLine(pen,a,b,c,d);
								g1--;
								a=a+50;
								c=c+50;
							}while(g1>0);
							
						}
					    else if(ostatokFor500==0 & ostatokFor400!=0)//готово
						{
							billetsFor500end400++;
							ostatokFor400 = 4000-ostatokFor400*400;
							label7.Text="Вам нужно " +billetsFor500end400.ToString()+" шт. станд.форм.";
							label6.Text="Ваши отходы составляют "+ostatokFor400.ToString()+ " мм.";
							int g=10-ostatokFor400/400;
							label1.Text="400*"+g.ToString()+"=1 шт. станд.форм.";
							label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
					
							
							int a=40,b=0,c=40,d=200;
							do
							{
								graph.DrawLine(pen,a,b,c,d);
								g--;
								a=a+40;
								c=c+40;
							}while(g>0);
						}
					    else if(ostatokFor500!=0 & ostatokFor400==0)//готово
					    {
					    	billetsFor500end400++;
							ostatokFor500 = 4000-ostatokFor500*500;
							label7.Text="Вам нужно " +billetsFor500end400.ToString()+" шт. станд.форм.";
							label6.Text="Ваши отходы составляют "+ostatokFor500.ToString()+ " мм.";
							
							int g=ostatokFor500/500;
							label1.Text="500*"+g.ToString()+"=1 шт. станд.форм.";
							label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
					
							
							int a=50,b=0,c=50,d=200;
							do
							{
								graph.DrawLine(pen,a,b,c,d);
								g--;
								a=a+50;
								c=c+50;
							}while(g>0);
					    }
					     else if(ostatokFor500!=0 & ostatokFor400!=0) // оба остатка не равно 0
					    {
					    	
							ostatokFor500 = ostatokFor500*500;//  7 6 5 3 2 1      3500 3000 2500 1500 1000 500
							ostatokFor400 = ostatokFor400*400;//  9 8 7 6 4 3 2 1  3600 3200 2800 2400 1600 1200 800 400
							int ostatokFor500end400= ostatokFor400+ostatokFor500;
							
							if(ostatokFor500end400>4000)
							{
								
								billetsFor500end400 = billetsFor500end400+2;
								int g1=ostatokFor400/400;// int
								int g2=ostatokFor500/500;//int
								int ii=0;
								if(ostatokFor400>=2000 & ostatokFor500>=2000)//готово
								{
									g1=g1-5;
									g2=g2-4;
									ostatokFor400=ostatokFor400-2000;
									ostatokFor500=ostatokFor500-2000;
									ostatokFor500end400=4000-(ostatokFor500+ostatokFor400);
									label6.Text="Ваши отходы составляют "+ostatokFor500end400.ToString()+ " мм.";
									
									label1.Text="400*5 и 500*4=1 шт. станд.форм и 400*"+g1.ToString()+" и 500*"+g2.ToString()+"= 1 шт. станд.форм.";
									label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
									int a=0,b=0,c=0,d=200;
									while(g2>=1)
									{
										a=a+50;
										c=c+50;
										graph.DrawLine(pen,a,b,c,d);
										g2--;
									}
									while(g1>=1)
									{
										a=a+40;
										c=c+40;
										graph.DrawLine(pen,a,b,c,d);
										g1--;
									}
									}
								else// готово
								{
									int o500=ostatokFor500;
									int o400=ostatokFor400;
									int oo500=o500/500;
									int i=0;
									int g11=g1;
									int g222=g2;
									int g111=g1;
									bool p=true;
									//int g1=ostatokFor400/400;// int
									//int g2=ostatokFor500/500;//int
									//int ii=0;
									do
								 {
									ostatokFor500=ostatokFor500+400;
									ostatokFor400=ostatokFor400-400;
									g1--;
									ii++;
								 } while(ostatokFor500<=3500);
								
								 ostatokFor500=4000-ostatokFor500;
								 ostatokFor400=4000-ostatokFor400;
								 
								 if(ostatokFor500>=200)
								 {
								 	p=false;
								 	while(o400<=3500)
								 	{
								 		
								 		o400=o400+500;
								 		o500=o500-500;
								 		i++;//кол-во 500 в итоге а g1 кол-во 400
								 		
								 	}
								 	g2=g2-i;
								 	ostatokFor500=4000-o400;
								    ostatokFor400=4000-o500;
								    
								    label1.Text="400*"+g11.ToString()+" и 500*"+i.ToString()+"= 1 станд.форма и 500*"+g2.ToString()+"=1 станд.форма.";
								    label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
								 
								 }
								
								 else
								 {
								 	label1.Text="400*"+g1.ToString()+"= 1 шт. станд.форм и 500*"+g2.ToString()+" и 400*"+ii.ToString()+"=1 станд.форма.";
								    label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
								 
								 }

								 label6.Text="Ваши отходы составляют "+ostatokFor500.ToString()+ " мм. и "+ostatokFor400.ToString()+ " мм.";
								 int x1=0,y1=0,x2=0,y2=0;
								 int a=0,b=0,c=0,d=200;
								 if(p==true)
								 {
								 	x1=50;
								 	y1=g222;
								 	x2=40;
								 	y2=g111;
								 }
								 else if (p==false)
								 {
								 	x1=40;
								 	y1=g111;
								 	x2=50;
								 	y2=g222;
								 }
									while(y1>=1)
									{
										a=a+x1;
										c=c+x1;
										graph.DrawLine(pen,a,b,c,d);
										y1--;
									}
									
									while(y2>=1)
									{
										a=a+x2;
										c=c+x2;
										graph.DrawLine(pen,a,b,c,d);
										y2--;
										
									}
								}
								
								label7.Text="Вам нужно " +billetsFor500end400.ToString()+" шт. станд.форм.";
							}
							else if(ostatokFor500end400<4000)//готово
							{
								billetsFor500end400++;
								ostatokFor500end400=4000-ostatokFor500end400;
								label7.Text="Вам нужно " +billetsFor500end400.ToString()+" шт. станд.форм.";
								label6.Text="Ваши отходы составляют "+ostatokFor500end400.ToString()+ " мм.";
								
								int g1=ostatokFor400/400;
								int g2=ostatokFor500/500;
								label1.Text="400*"+g1.ToString()+" и 500*"+g2.ToString()+"=1 шт. станд.форм.";
								label2.Text="400*10= "+billetsFor400.ToString()+" шт. станд.форм и 500*8= "+billetsFor500.ToString()+" шт. станд.форм.";
					
							
								int a=0,b=0,c=0,d=200;
								while(g1>=1)
								{
									a=a+40;
									c=c+40;
									graph.DrawLine(pen,a,b,c,d);
									g1--;
								}
								while(g2>=1)
								{
									a=a+50;
									c=c+50;
									graph.DrawLine(pen,a,b,c,d);
									g2--;
									}
							}
							}
						}
				 }
				else if( textBox3.TextLength!=0) // введено только в поле 500
			{
				
					Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
					Graphics graph = Graphics.FromImage(bmp);
					Pen pen = new Pen(Color.Black);
					graph.DrawRectangle(pen,0,0,400,200);
					pictureBox1.Image=bmp;
					int n500 = Convert.ToInt32(Convert.ToUInt32(textBox3.Text));//кол-во деталей по 500мм
				
				int sum=500*n500;
				
				if(sum> 4000)//готово
				{
					int i =0;
					do
					{
						sum=sum-4000;
						i++;// кол-во заготовок именно здесь
						n500=n500-8;
					} while(sum>4000);
						ostatok500=4000-sum;
					
					label7.Text="Ваши отходы составляют: "+ ostatok500.ToString()+ " мм";
					label6.Text="Вам необходимо приобрести "+(i+1).ToString()+ " шт. станд.форм.";
					label1.Text="500*"+n500+"=1 шт.станд.форма.";
					label2.Text="500*8= "+i.ToString()+"шт.станд.форм.";
					
					int g=n500;
					int a=50,b=0,c=50,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+50;
						c=c+50;
					}while(g>0);
				}
				else if(sum<4000)//готово
				{
					int result = 4000 - sum;
					//int count = 1;
					label7.Text="Ваши отходы составляют в мм : "+ result.ToString();
					label6.Text="Вам необходима всего одна станд.форма.";
					
					label1.Text="500*"+n500;
					
					int g=n500;
					int a=50,b=0,c=50,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+50;
						c=c+50;
					}while(g>0);
					}
				else if(sum==4000)//готово
				{
					label7.Text="Поздравляем!Ваши отходы составляют 0 мм.";
					label6.Text="Вам необходима всего одна станд.форма.";
					label1.Text="500*8";
					
					int g=7;
					int a=50,b=0,c=50,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+50;
						c=c+50;
					}while(g>0);
				}
			}
			
			else if( textBox4.TextLength!=0)// введено только в поле 400
			{
				
				Bitmap bmp = new Bitmap(pictureBox1.Width,pictureBox1.Height);
				Graphics graph = Graphics.FromImage(bmp);
				Pen pen = new Pen(Color.Black);
				graph.DrawRectangle(pen,0,0,400,200);
				
				pictureBox1.Image=bmp;
				int n400 = Convert.ToInt32(Convert.ToUInt32(textBox4.Text));//кол-во деталей по 400мм
				int sum=400*n400;
				if(sum> 4000)// готово
				{
					int i =0;
					do
					{
						sum=sum-4000;
						i++;// кол-во заготовок именно здесь
						n400=n400-10;
					} while(sum>4000);
						ostatok400=4000-sum;
					
					label7.Text="Ваши отходы составляют: "+ ostatok400.ToString()+ " мм.";
					label6.Text="Вам необходимо приобрести "+(i+1).ToString()+ " станд.форм.";
					label1.Text="400*"+n400+"=1 шт. станд.форм.";
					label2.Text="400*10= "+i.ToString()+" шт. станд.форм.";
					
					int g=n400;
					int a=40,b=0,c=40,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+40;
						c=c+40;
					}while(g>0);
				}
				else if(sum<4000)//готово
				{
					int result = 4000 - sum;
					
					label7.Text="Ваши отходы составляют в мм : "+ result.ToString();
					label6.Text="Вам необходима всего одна станд.форма.";
					label1.Text="400*"+n400;
					int g=n400;
					int a=40,b=0,c=40,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+40;
						c=c+40;
					}while(g>0);
				}
				else if(sum==4000)//готово
				{
					label7.Text="Поздравляем!Ваши отходы составляют 0 мм.";
					label6.Text="Вам необходима всего одна станд.форма.";	
					label1.Text="400*10";
		
					int g=9;
					int a=40,b=0,c=40,d=200;
					do
					{
						graph.DrawLine(pen,a,b,c,d);
						g--;
						a=a+40;
						c=c+40;
					}while(g>0);	
				}
			}
			}
			 else
			 {
			 	label7.Text="Вы ничего не ввели, попытайтесь еще раз.";
			 }
			}
	}
}
		
		
		
		
	