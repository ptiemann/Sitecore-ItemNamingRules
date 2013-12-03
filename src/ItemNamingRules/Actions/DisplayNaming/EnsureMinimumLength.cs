
namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
	/// <summary>
	/// Rules engine action to change DisplayName with characters from 
	/// <see cref="DefaultName" /> if the name does not meet or exceed
	/// the number of characters in that string.
	/// </summary>
	/// <typeparam name="T">Type providing rule context.</typeparam>
   public class EnsureMinimumLength<T> : ChangeDisplayNameAction<T>
       where T : Sitecore.Rules.RuleContext
	{
		/// <summary>
		/// Gets or sets the string from which to append characters 
		/// to item DisplayNames that are not longer than this string.
		/// </summary>
		public string DefaultDisplayName
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
            if (ruleContext.Item.Name.Length >= this.DefaultDisplayName.Length)
			{
				return;
			}
            string newName = ruleContext.Item.Name + this.DefaultDisplayName.Substring(
			  ruleContext.Item.Name.Length - 1);
			this.ChangeDisplayName(ruleContext.Item, newName);
		}
	}
}
