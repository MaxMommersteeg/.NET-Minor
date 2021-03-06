// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Case2.MaRoWo.GarageAdministratie.Infrastructure.Agents.RdwIntegrationService
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for RdwIntegrationServiceAgent.
    /// </summary>
    public static partial class RdwIntegrationServiceAgentExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='command'>
            /// </param>
            public static object MakeApkRequest(this IRdwIntegrationServiceAgent operations, ApkKeuringsVerzoekCommand command = default(ApkKeuringsVerzoekCommand))
            {
                return Task.Factory.StartNew(s => ((IRdwIntegrationServiceAgent)s).MakeApkRequestAsync(command), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='command'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> MakeApkRequestAsync(this IRdwIntegrationServiceAgent operations, ApkKeuringsVerzoekCommand command = default(ApkKeuringsVerzoekCommand), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.MakeApkRequestWithHttpMessagesAsync(command, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
