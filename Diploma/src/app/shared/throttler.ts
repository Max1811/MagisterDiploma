export class ThrottlingExecutor {

    private to: number;

    constructor(private timeout: number = 100) {
    }

    public schedule(action: () => void, timeout?: number): void {
        this.destroy();
        this.to = window.setTimeout(action, timeout ?? this.timeout);
    }

    public destroy() {
        if (this.to) {
            clearTimeout(this.to);
        }
    }
    
}