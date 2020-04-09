import { Injectable, Output } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class ResetService {
  @Output() reset = true;

  constructor() { }
  resetView() {
    setTimeout(() => this.reset = false);
    setTimeout(() => this.reset = true);
  }
}
