pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/Yura-2005/_BenefitCalculator_.git'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Run Tests') {
            steps {
                // Видаляємо старі результати тестів
                sh 'rm -rf TestResults/*'

                // Запускаємо тести та зберігаємо результати у форматі trx
                sh 'dotnet test BenefitCalculator.Tests/BenefitCalculator.Tests.csproj --logger "trx;LogFileName=test-results.trx" --results-directory TestResults'
            }
        }
    }

    post {
        always {
            // Публікуємо результати тестів у форматі trx
            mstest testResultsFile: '**/TestResults/test-results.trx'
        }
    }
}
