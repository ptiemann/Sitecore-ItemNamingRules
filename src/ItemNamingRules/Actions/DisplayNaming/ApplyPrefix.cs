using System;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions.DisplayNaming
{
    /// <summary>
    /// Rules engine action to apply a prefix to the beginning of an item name.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class ApplyPrefix<T> : ChangeDisplayNameAction<T> where T : Sitecore.Rules.RuleContext
    {
        /// <summary>
        /// Gets or sets the string with which to prefix in item names.
        /// </summary>
        public string Prefix
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
            if (!ruleContext.Item.DisplayName.StartsWith(this.Prefix))
            {
                string newName = String.Concat(Prefix, ruleContext.Item.DisplayName);
                if (ruleContext.Item.DisplayName != newName)
                {
                    this.ChangeDisplayName(ruleContext.Item, newName);
                }
            }
        }
    }
}
