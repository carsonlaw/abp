using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Localization.VirtualFiles.Json;
using Volo.Match.EntityFrameworkCore.LocalizationDB;

namespace Volo.Abp.Localization
{
    public static class DBLocalizationResourceExtensions
    {
        public static LocalizationResource AddDB(
            [NotNull] this LocalizationResource localizationResource,
            [NotNull] string virtualPath)
        {
            Check.NotNull(localizationResource, nameof(localizationResource));
            Check.NotNull(virtualPath, nameof(virtualPath));

            localizationResource.Contributors.Add(new DBLocalizationContributor(
            ));

            return localizationResource;
        }

        public static LocalizationResource AddBaseTypes(
            [NotNull] this LocalizationResource localizationResource,
            [NotNull] params Type[] types)
        {
            Check.NotNull(localizationResource, nameof(localizationResource));
            Check.NotNull(types, nameof(types));

            foreach (var type in types)
            {
                localizationResource.BaseResourceTypes.AddIfNotContains(type);
            }

            return localizationResource;
        }
    }
}