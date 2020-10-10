import { Component, OnInit } from '@angular/core';
import { CarouselComponent } from 'angular-responsive-carousel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  images: any[] = [
    '/assets/images/hero1.jpg',
    '/assets/images/hero2.jpg',
    '/assets/images/hero3.jpg'
  ];
  image = 0;
  constructor() { }

  ngOnInit(): void {
  }

  selectImg(){
    if (this.image === 2){
      this.image = 0;
    }
    else{
      this.image++;
    }
  }

}
