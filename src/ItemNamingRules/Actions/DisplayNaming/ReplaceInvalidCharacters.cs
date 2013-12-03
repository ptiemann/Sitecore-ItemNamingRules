using System;
using System.Text.RegularExpressions;
using Sitecore.Rules;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    /// <summary>
	/// Rules engine action to replace invalid characters in item names.
	/// </summary>
	/// <typeparam name="T">Type providing rule context.</typeparam>
    // TODO: Created Sitecore Item "/sitecore/system/Settings/Rules/Common/Actions/ReplaceInvalidCharacters" when creating ReplaceInvalidCharacters class. Fix Title field.

    public class ReplaceInvalidCharacters<T> :ChangeDisplayNameAction<T> where T : RuleContext
    {
		/// <summary>
		/// Gets or sets the string with which to replace invalid characters
		/// in item names.
		/// </summary>
		public string ReplaceWith
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the regular expression used to validate each character
		/// in item names.
		/// </summary>
		public string MatchPattern
		{
			get;
			set;
		}

		/// <summary>
		/// Action implementation.
		/// </summary>
		/// <param name="ruleContext">The rule context.</param>
        public override void Apply([NotNull] T ruleContext)
        {
			Sitecore.Diagnostics.Assert.IsNotNull(this.ReplaceWith, "ReplaceWith");
			Regex patternMatcher = new Regex(this.MatchPattern);
			string newName = String.Empty;

			foreach (char c in ruleContext.Item.DisplayName)
			{
				if (patternMatcher.IsMatch(c.ToString()))
				{
					newName += c;
				}
				else if (!String.IsNullOrEmpty(this.ReplaceWith))
				{
					newName += this.ReplaceWith;
				}
			}

			while (newName.StartsWith(this.ReplaceWith))
			{
				newName = newName.Substring(
				  this.ReplaceWith.Length,
				  newName.Length - this.ReplaceWith.Length);
			}

			while (newName.EndsWith(this.ReplaceWith))
			{
				newName = newName.Substring(
				  0,
				  newName.Length - this.ReplaceWith.Length);
			}

			string sequence = this.ReplaceWith + this.ReplaceWith;

			while (newName.Contains(sequence))
			{
				newName = newName.Replace(sequence, this.ReplaceWith);
			}

			if (String.IsNullOrEmpty(newName))
			{
				newName = this.ReplaceWith;
			}

			if (ruleContext.Item.DisplayName != newName)
			{
				this.ChangeDisplayName(ruleContext.Item, newName);
			}
		}
	}
}