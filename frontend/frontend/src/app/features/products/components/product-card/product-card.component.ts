import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../../models/product.model';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-product-card',
  standalone: true,
  imports: [MatCardModule, MatButtonModule],
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {

  @Input() product!: Product;
  @Output() deleted = new EventEmitter<number>();

  constructor(private router: Router) {}

  detailProduct() {
    this.router.navigate(['/detail', this.product.id]);
  }

  editProduct() {
    this.router.navigate(['/edit', this.product.id]);
  }

  deleteProduct() {
    this.deleted.emit(this.product.id);
  }
}