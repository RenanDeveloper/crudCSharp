   M S B A M L   `   `   `  ?????  ;CRUD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRUDCRUD  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       CRUD.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:CRUD     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? 	Resources 5
         dataEnum S? 
MethodName S? 
ObjectType  System.Enum S? MethodParameters M? TypeName??%w   &	        S? 5   
   $ 	GetValues??6.   "  6E    5      M? 5      $ local:Enumeravel??6   5      5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??189* ?6   ?? 5      $
??611* ?6   .+?5   
   ?? -   5        $??minhaListView??5      $??91,0,0,0q?6?   $??1??6?   ??6S   ??  ?? Path$ listaLinkada? ?? Mode$ OneWay=?	 ?? SelectedItem	 6?   ?? $ produtoSelecionado?
 ?? View
 5      ?? 5      .P?5      ??  ?? DisplayMemberBinding 6%   ?? $
 Nome??? 5       6%   ?? $ 	Categoria??? 5       6%   ?? $ 	CodBarras??? 5       6%   ?? $ Login??? 5       6%   ?? $ Password??? 5       6%   ?? $ Preco??? 5       6%   ?? $
 Tipo?5"      5$      ?? 5%   
   -   5        $??ComboAdicionarProdutos??5%      $
??Left=?6?   $??	33,63,0,0q?6?   $	??Top=?6?   $	??142??6?   $??22??6
  ??61   ??  ?? Source# [  	 6j   ?? *ProdutoEnumeravel+ ?? Text 6?   ?? *ProdutoEnumeravel+6  ?? 5&   
   -   5        $??Btn_Adicionar??5&      $??	Adicionar??6&   $
??Left=?6X   $??
77,172,0,0q?6s   $	??Top=?6?   ??6:   ?? *	Adicionar+6?   ?? 5'   
   -   5        $??Btn_Remover??5'      $??Remover??6$   $
??Left=?6Q   $??
79,217,0,0q?6l   $	??Top=?6?   ??66   ?? *Remove+6?   ?? 5(   
   -   5        $??
Btn_Editar??5(      $??Editar??6#   $
??Left=?6P   $??
87,263,0,0q?6k   $	??Top=?6   ??64   ?? *	Alterar+6   5*      5+      