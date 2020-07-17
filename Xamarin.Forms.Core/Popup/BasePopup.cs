﻿using System;

namespace Xamarin.Forms
{
	public abstract class BasePopup : VisualElement
	{
		protected internal BasePopup()
		{
			Color = Color.White;
			BorderColor = default(Color);
			VerticalOptions = LayoutOptions.CenterAndExpand;
			HorizontalOptions = LayoutOptions.CenterAndExpand;
		}

		public static BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(BasePopup));
		public static BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(BasePopup));
		public static BindableProperty VerticalOptionsProperty = BindableProperty.Create(nameof(VerticalOptions), typeof(LayoutOptions), typeof(BasePopup), LayoutOptions.CenterAndExpand);
		public static BindableProperty HorizontalOptionsProperty = BindableProperty.Create(nameof(HorizontalOptions), typeof(LayoutOptions), typeof(BasePopup), LayoutOptions.CenterAndExpand);

		/// <summary>
		/// Gets or sets the <see cref="View"/> to render in the Popup.
		/// </summary>
		/// <remarks>
		/// The View can be or type: <see cref="View"/>, <see cref="ContentPage"/> or <see cref="NavigationPage"/>
		/// </remarks>
		public virtual View View { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Color"/> of the Popup.
		/// </summary>
		/// <remarks>
		/// This color sets the native background color of the <see cref="Popup"/>, which is
		/// independent of any background color configured in the actual View.
		/// </remarks>
		public Color Color
		{
			get => (Color)GetValue(ColorProperty);
			set => SetValue(ColorProperty, value);
		}

		/// <summary>
		/// Gets or sets the <see cref="LayoutOptions"/> for positioning the <see cref="Popup"/> vertically on the screen.
		/// </summary>
		public LayoutOptions VerticalOptions
		{
			get => (LayoutOptions)GetValue(VerticalOptionsProperty);
			set => SetValue(VerticalOptionsProperty, value);
		}

		/// <summary>
		/// Gets or sets the <see cref="LayoutOptions"/> for positioning the <see cref="Popup"/> horizontally on the screen.
		/// </summary>
		public LayoutOptions HorizontalOptions
		{
			get => (LayoutOptions)GetValue(HorizontalOptionsProperty);
			set => SetValue(HorizontalOptionsProperty, value);
		}

		/// <summary>
		/// Gets or sets the <see cref="Color"/> of the Popup Border.
		/// </summary>
		/// <remarks>
		/// This color sets the native border color of the <see cref="Popup"/>, which is
		/// independent of any border color configured in the actual view.
		/// </remarks>
		public Color BorderColor { get; set; } // UWP ONLY - wasn't originally in spec

		/// <summary>
		/// Gets or sets the <see cref="View"/> anchor.
		/// </summary>
		/// <remarks>
		/// The Anchor is where the Popup will render closest to. When an Anchor is configured
		/// the popup will appear centered over that control or as close as possible.
		/// </remarks>
		public View Anchor { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Size"/> of the Popup Display. 
		/// </summary>
		/// <remarks>
		/// The Popup will always try to constrain the actual size of the <see cref="Popup" />
		/// to the <see cref="Popup" /> of the View unless a <see cref="Size"/> is specified.
		/// If the <see cref="Popup" /> contiains <see cref="LayoutOptions"/> a <see cref="Size"/>
		/// will be required. This will allow the View to have a concept of <see cref="Size"/>
		/// that varies from the actual <see cref="Size"/> of the <see cref="Popup" />
		/// </remarks>
		public Size Size
		{
			get => (Size)GetValue(SizeProperty);
			set => SetValue(SizeProperty, value);
		}

		public bool IsLightDismissEnabled { get; set; }

		public event EventHandler<PopupDismissedEventArgs> Dismissed;

		protected virtual void OnDismissed(object result)
		{
			Dismissed?.Invoke(this, new PopupDismissedEventArgs { Result = result });
		}

		public virtual void LightDismiss()
		{
			// empty default implementation
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (View != null)
			{
				SetInheritedBindingContext(View, BindingContext);
			}
		}
	}
}