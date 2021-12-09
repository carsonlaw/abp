import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'HDShop',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44397',
    redirectUri: baseUrl,
    clientId: 'HDShop_App',
    responseType: 'code',
    scope: 'offline_access HDShop role email openid profile',
  },
  apis: {
    default: {
      url: 'https://localhost:44397',
      rootNamespace: 'Volo.HDShop',
    },
    HDShop: {
      url: 'https://localhost:44394',
      rootNamespace: 'Volo.HDShop',
    },
  },
} as Environment;
