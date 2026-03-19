import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./features/products/pages/product-list/product-list.component')
        .then(m => m.ProductListComponent)
  },
  {
    path: 'new',
    loadComponent: () =>
      import('./features/products/pages/product-form/product-form.component')
        .then(m => m.ProductFormComponent)
  },
  {
    path: 'edit/:id',
    loadComponent: () =>
      import('./features/products/pages/product-form/product-form.component')
        .then(m => m.ProductFormComponent)
  },
  {
    path: 'detail/:id',
    loadComponent: () =>
      import('./features/products/pages/product-detail/product-detail.component')
        .then(m => m.ProductDetailComponent)
  }
];
