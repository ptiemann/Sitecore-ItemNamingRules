using System;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
	/// <summary>
	/// Rules engine action to apply a suffix to the end of an item's display.
	/// </summary>
	/// <typeparam name="T">Type providing rule context.</typeparam>

    public class ApplySuffix<T> : ChangeDisplayNameAction<T> where T : Sitecore.Rules.RuleContext
	{
		/// <summary>
		/// Gets or sets the string with which to suffix with in item DisplayNames.
		/// </summary>
		public string Suffix
		{
			get;
			set;
		}

		/// <summary>
		/// Action implementation.
		/// </summary>
		/// <param name="ruleContext">The rule context.</param>
		public override void Apply(T ruleContext)
		{
			if (!ruleContext.Item.DisplayName.EndsWith(this.Suffix))
			{
				string newName = String.Concat(ruleContext.Item.Name, this.Suffix);
				if (ruleContext.Item.Name != newName)
				{
					this.ChangeDisplayName(ruleContext.Item, newName);
				}
			}
		}
	}
}
