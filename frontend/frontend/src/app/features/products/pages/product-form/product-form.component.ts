import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { FormBuilder, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { ProductService } from '../../../../core/services/product.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  standalone: true,
    imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatToolbarModule,
    MatCardModule
  ],
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.scss']
})
export class ProductFormComponent implements OnInit {

  form!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: ProductService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.form = this.fb.group({
      id: [0],
      name: [''],
      price: [0],
      image: ['']
    });

    const id = this.route.snapshot.params['id'];
    if (id) {
      this.service.getById(id).subscribe(p => this.form.patchValue(p));
    }
  }

  saveProduct() {
    const data = this.form.value;

    if (data.id) {
      this.service.update(data.id, data).subscribe(() => this.router.navigate(['/']));
    } else {
      this.service.create(data).subscribe(() => this.router.navigate(['/']));
    }
  }
}