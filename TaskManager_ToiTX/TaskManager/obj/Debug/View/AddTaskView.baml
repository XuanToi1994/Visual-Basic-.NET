   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.AddTaskView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  AddTaskView��5   	    � WindowStartupLocation$ CenterScreen=�6   $��327.188��6B   ���#FFFFCC$��365.938��6h    � DataContext 5	      "   TaskManager.AddTaskViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	Name task��6   $��20q�6)   $	��100��65   �� 5      $	��200��61   $��20��6=   $��	0,22,0,21q�6I   ��6   �� *	Task.Name+6I   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   .+�5      �� $��Content��6   $��20q�6'   $	��100��63   �� 5      $	��200��64   $��20��6@   $��	0,22,0,21q�6L   ��6   �� *Task.Content+6L   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   .+�5      �� $��	Catelogry��6   $��20q�6)   $	��100��65   �� 5       $	��200��65   $��20��6A   $��	0,22,0,21q�6M   ��6   �� *Task.Category+6M   5!      �� 5#   
   $ 
Horizontal=�6   $��3��6.   $��Right=�6;   .+�5$      �� $
��Save��6   $��60��6$   $��20q�6/   ���#33FFCC��6P   �� *	SaveCmd+�� 5%      -   5        $��Cance��5%      $��60��6%   $��20q�60   ���#FF66006Q   5&      5'      5(      