using Sitecore.Rules;
using System;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    /// <summary>
    ///     Rules engine action to apply a suffix to the end of an item name.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class ApplySuffix<T> : RenamingAction<T> where T : RuleContext
    {
        /// <summary>
        ///     Gets or sets the string with which to suffix with in item names.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        ///     Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.Name.EndsWith(Suffix)) return;

            var newName = String.Concat(ruleContext.Item.Name, Suffix);
            if (ruleContext.Item.Name != newName)
            {
                RenameItem(ruleContext.Item, newName);
            }
        }
    }
}