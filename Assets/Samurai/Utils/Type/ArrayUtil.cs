﻿using System;
using System.Collections.Generic;

namespace Samurai.Utils
{
	public class ArrayUtil
	{
		public ArrayUtil ()
		{

		}

		private static Random rng = new Random();

		public static void Shuffle<T>(IList<T> list)  
		{  
			int n = list.Count;  
			while (n > 1) {  
				n--;  
				int k = rng.Next(n + 1);  
				T value = list[k];  
				list[k] = list[n];  
				list[n] = value;  
			}  
		}

	}
}

