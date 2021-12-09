import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Match',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44304',
    redirectUri: baseUrl,
    clientId: 'Match_App',
    responseType: 'code',
    scope: 'offline_access Match role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44304',
      rootNamespace: 'Volo.Match',
    },
    Match: {
      url: 'https://localhost:44325',
      rootNamespace: 'Volo.Match',
    },
  },
} as Environment;
