﻿using SEGroup5.Views;

namespace SEGroup5;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}


private async void OnNavigateToMenuPage(object sender, EventArgs e)
{
    await Navigation.PushAsync(new Menu());
}


}

