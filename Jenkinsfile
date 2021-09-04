pipeline{
    agent{
        label "any"
    }
    stages{
        stage("build"){
            steps{
                echo "========executing A========"
                
            }
            
        }
        stage("publish"){
            steps{
                echo "========executing A========"
            }
            
        }
    }
    post{
        always{
            echo "========always========"
        }
        success{
            echo "========pipeline executed successfully ========"
        }
        failure{
            echo "========pipeline execution failed========"
        }
    }
}