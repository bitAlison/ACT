import { CommonModule } from '@angular/common';
import { ProductCardComponent } from '../../components/product-card/product-card.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../../core/services/product.service';
import { Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';
import { Product } from '../../models/product.model';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    ProductCardComponent,
    MatToolbarModule,
    MatButtonModule
  ],
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];

  constructor(
    private service: ProductService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.load();
  }

  load() {
    //this.service.getAll().subscribe(res => this.products = res);
    // this.service.getAll().subscribe(res => {
    //   setTimeout(() => {
    //     this.products = res;
    //   });
    // });
    this.service.getAll().subscribe(res => {
      this.products = res;
      this.cdr.detectChanges();
    });
  }

  newProduct() {
    this.router.navigate(['/new']);
  }

  editProduct(id: number) {
    this.router.navigate(['/edit', id]);
  }

  detailProduct(id: number) {
    this.router.navigate(['/detail', id]);
  }

  deleteProduct(id: number) {
    this.service.delete(id).subscribe(() => this.load());
  }
}