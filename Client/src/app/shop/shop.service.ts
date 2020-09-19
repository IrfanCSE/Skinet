import { Type } from './../shared/Models/productType';
import { Brand } from './../shared/Models/brand';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Pageination } from '../shared/Models/pageination';
import { ProductParams } from '../shared/Models/productParams';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(productParams: ProductParams) {
    let param = new HttpParams();

    if (productParams.brandId){
      param = param.append('brandId', productParams.brandId.toString());
    }

    if (productParams.typeId){
      param = param.append('typeId', productParams.typeId.toString());
    }

    if(productParams.search !== null && productParams.search !== undefined){
      param = param.append('search',productParams.search);
    }

    if(productParams.pageIndex){
      param = param.append('pageIndex',productParams.pageIndex.toString());
    }

    param = param.append('sort', productParams.sort);

    return this.http.get<Pageination>(this.baseUrl + 'products', {observe: 'response', params: param})
    .pipe(
      map(response =>{
        return response.body;
      })
    );
  }

  getBrands(){
    return this.http.get<Brand[]>(this.baseUrl + 'products/brands');
  }

  getTypes(){
    return this.http.get<Type[]>(this.baseUrl + 'products/types');
  }

}
