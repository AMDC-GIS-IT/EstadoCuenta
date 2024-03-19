import { EventEmitter } from '../../stencil-public-runtime';
export declare class K2btMaskedInput {
  mask?: string;
  numeric: boolean;
  enabled: boolean;
  inputclass: string;
  readonlyclass: string;
  value: string;
  uppercase: boolean;
  inputEvent: EventEmitter<object>;
  changeEvent: EventEmitter<object>;
  nativeInput?: HTMLInputElement;
  getUnformattedValue(): Promise<any>;
  getFormattedValue(): Promise<string>;
  componentDidLoad(): void;
  SYMBOL_OPTIONAL_DIGIT: string;
  SYMBOL_OPTIONAL_LETTER: string;
  SYMBOL_DIGIT: string;
  SYMBOL_LETTER: string;
  SYMBOL_CHARACTER: string;
  SYMBOL_ESCAPE: string;
  SYMBOL_MASK_SEPARATOR: string;
  LANGUAGE_SYMBOLS: string[];
  private getInputMask;
  getTransformedMask(mask: string): any;
  reorderOptionalCharacters(mask: string): string;
  INPUTMASK_SPECIAL_CHARS: string;
  escape_char(c: string): string;
  changeTimeout: any;
  onInput(): void;
  render(): any;
}
