import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../features/products/models/product.model';
import { catchError, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private api = 'https://localhost:7092/api/products';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.api).pipe(
      catchError(() => of([]))
    );
  }

  getById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.api}/${id}`);
  }

  create(product: Product) {
    return this.http.post(this.api, product);
  }

  update(id: number, product: Product) {
    return this.http.put(`${this.api}/${id}`, product);
  }

  delete(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }
}