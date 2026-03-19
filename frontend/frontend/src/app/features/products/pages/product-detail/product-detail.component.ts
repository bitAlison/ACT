import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectorRef } from '@angular/core';
import { Location } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';

import { ProductService } from '../../../../core/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product.model';

@Component({
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule
  ],
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product!: Product;

  constructor(
    private service: ProductService,
    private route: ActivatedRoute,
    private location: Location,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit() {
    const id = Number(this.route.snapshot.params['id']);
    //console.log('ID:', id);
    this.service.getById(id).subscribe(res => {
      //console.log('Produto:', res);
      this.product = res;
      this.cdr.detectChanges();
    });
  }


  backPage() {
    this.location.back();
  }
}