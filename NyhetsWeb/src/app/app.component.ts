import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'NyhetsWeb';
  links = [
    { title: 'Nyhetsflöde', href: '' },
    { title: 'Norrköpings Tidningar', href: '/norrkoping-newspapers' },
    { title: 'Expressen', href: '/expressen' },
    { title: 'SvD', href: '/svd' }
  ];
}
