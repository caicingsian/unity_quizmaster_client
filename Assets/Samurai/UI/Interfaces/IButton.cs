using System;
using strange.extensions.signal.impl;

namespace Samurai.UI
{
	public interface IButton
	{
		Signal<IButton> OnClick{ get; }
		bool enable{ get; set;}
	}
}

