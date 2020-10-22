import { v4 as uuidv4 } from 'uuid';

export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export interface IBasketItem {
  id: number;
  productName: string;
  quantity: number;
  price: number;
  pictureUrl: string;
  type: string;
  brand: string;
}

export class Basket implements IBasket{
  id = uuidv4();
  items: IBasketItem[] = [];
}
