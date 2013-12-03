using Sitecore.Rules;
using System;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    /// <summary>
    ///     Rules engine action to apply a prefix to the beginning of an item name.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class ApplyPrefix<T> : RenamingAction<T> where T : RuleContext
    {
        /// <summary>
        ///     Gets or sets the string with which to prefix in item names.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        ///     Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.Name.StartsWith(Prefix)) return;

            var newName = String.Concat(Prefix, ruleContext.Item.Name);
            if (ruleContext.Item.Name != newName)
            {
                RenameItem(ruleContext.Item, newName);
            }
        }
    }
}