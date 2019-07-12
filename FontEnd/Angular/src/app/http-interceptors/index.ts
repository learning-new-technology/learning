// #docplaster
// #docregion interceptor-providers
/* "Barrel" of Http Interceptors */
import { HTTP_INTERCEPTORS } from '@angular/common/http';

// #enddocregion interceptor-providers
import { EnsureHttpsInterceptor } from './ensure-https-interceptor';
// #docregion interceptor-providers
import { NoopInterceptor } from './noop-interceptor';
// #docregion interceptor-providers

/** Http interceptor providers in outside-in order */
export const HttpInterceptorProviders = [
  // #docregion noop-provider
  { provide: HTTP_INTERCEPTORS, useClass: NoopInterceptor, multi: true },
  // #enddocregion noop-provider, interceptor-providers

  // #docregion interceptor-providers
  { provide: HTTP_INTERCEPTORS, useClass: EnsureHttpsInterceptor, multi: true },
  // #enddocregion interceptor-providers
];
