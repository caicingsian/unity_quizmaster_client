using System;
using System.Collections.Generic;

namespace Samurai.QuizMaster
{
	public class QuestionVO
	{
		public readonly string id;
		public readonly QuestionType type;
		public readonly string describe;
		public readonly List<string> options = new List<string> ();
		public readonly string answer;

		public readonly string image;
		public readonly int diffcult;
		public readonly string author;

		public QuestionVO (string id, QuestionType type, string describe, List<string> options, string answer, string image, int diffcult, string author)
		{
			this.id = id;
			this.type = type;
			this.describe = describe;
			this.options = options;
			this.answer = answer;
			this.image = image;
			this.diffcult = diffcult;
			this.author = author;
		}
	}
}

