   M S B A M L   `   `   `  ����   
quickdbacc    quickdbacc.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  
MainWindow��$��510.623��$��580.721�� � SizeToContent$ WidthAndHeight=�.���  � ColumnDefinitions �� $
��539* ��� $	��19* �.+��� -    ��Name$ 	queryButn��$��Query��$
��Left=�$��
448,80,0,0q�$	��Top=�$	��109��$��85��$��16(�$��Verdana)�$��2���� -    ��Name$ inputSql��$
��Left=�$��69��$��
10,233,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��497��$	��SQL��&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid1��$
��Left=�$��
10,307,0,0q�$	��Top=�$	��167��$	��497��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * �� -    ��Name$ sqlStatement��$��SQL Statement��$
��Left=�$��
10,202,0,0q�$	��Top=�$	��177���� -   	 ��Name$	 	lbxDBType��$
��Left=�$��53��$��	10,10,0,0q�$	��Top=�$��84��.@��� -   $��MySQL���� -   $��	SQLServer���� -   $ lbServer��$��Server��$
��Left=�$��	14,88,0,0q�$	��Top=�$��52���� -	   $ 	txtServer��$
��Left=�$��23��$��	71,91,0,0q�$
 Wrap=�$	��Top=�$	��120��$��	DB Server���� -
   $ lbUser��$�� ��$
��Left=�$��
14,156,0,0q�$	��Top=��� -   $ lbUser1��$
��User��$
��Left=�$��
14,156,0,0q�$	��Top=��� -   $ txtDB��$
��Left=�$��23��$��
274,91,0,0q�$
 Wrap=�$��DB��$	��Top=�$	��160���� -   $
 lbPW��$��Password��$
��Left=�$��205,156,0,0q�$	��Top=��� -   $
 lbDB��$��DB��$
��Left=�$��
205,88,0,0q�$	��Top=�$��52���� -   $ txtUser��$
��Left=�$��23��$��
71,158,0,0q�$
 Wrap=�$
��User��$	��Top=�$	��120��G� -   
 G�Name$
 pwBox1��$
��Left=�$��274,156,0,0q�$	��Top=�$	��160�� J� RenderTransformOrigin$ 0.507,1.076&�$��25��	� -    	�Name$ rbWin��$��Windows Authentication��$
��Left=�$��
24,129,0,0q�$	��Top=� 	� 	GroupName$ Authentication�� d� 	IsChecked$
 TrueY�	� -   $ rbSQL��$��SQL Authentication��$
��Left=�$��197,129,0,0q�$	��Top=�$ Authentication��