import { Product } from './product';

export interface Pageination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: Product[];
}
