import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'FreeERP',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44373/',
    redirectUri: baseUrl,
    clientId: 'FreeERP_App',
    responseType: 'code',
    scope: 'offline_access FreeERP',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44373',
      rootNamespace: 'FreeERP',
    },
    FreeERP: {
      url: 'https://localhost:44330',
      rootNamespace: 'FreeERP',
    },
  },
} as Environment;
